﻿using Pulsar4X.Orbital;
using System;

namespace Pulsar4X.ECSLib
{
    public static class EntityExtensions
    {
        public static string GetDefaultName(this Entity entity)
        {
            if (entity.HasDataBlob<NameDB>())
                return entity.GetDataBlob<NameDB>().DefaultName;
            return "Unknown";
        }

        public static string GetOwnersName(this Entity entity)
        {
            if (entity.HasDataBlob<NameDB>())
                return entity.GetDataBlob<NameDB>().OwnersName;
            return "Unknown";
        }

        public static string GetName(this Entity entity, Guid factionID)
        {
            if (entity.HasDataBlob<NameDB>())
                return entity.GetDataBlob<NameDB>().GetName(factionID);
            return "Unknown";
        }

        public static void AddComponent(this Entity entity, ComponentInstance component)
        {
            EntityManipulation.AddComponentToEntity(entity, component);
        }

        public static void AddComponent(this Entity entity, ComponentDesign componentDesign, int count = 1)
        {
            EntityManipulation.AddComponentToEntity(entity, componentDesign, count);
        }

        public static PositionDB GetSOIParentPositionDB(this Entity entity)
        {
            return (PositionDB)entity.GetDataBlob<PositionDB>().ParentDB;
        }


        /// <summary>
        /// Gets the Sphere of influence parent (the entity this object is orbiting) for a given entity.
        /// *Does not check if the entity is infact within the sphere of influence, just the current position heirarchy.*
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="positionDB">provide this to save looking it up</param>
        /// <returns></returns>
        public static Entity GetSOIParentEntity(this Entity entity, PositionDB positionDB = null)
        {
            if (positionDB == null)
                positionDB = entity.GetDataBlob<PositionDB>();

            return positionDB == null ? null : positionDB.Parent;
        }

        public static (Vector3 pos, Vector3 Velocity) GetRelativeState(this Entity entity)
        {
            var pos = entity.GetDataBlob<PositionDB>().RelativePosition;
            if (entity.HasDataBlob<OrbitDB>())
            {
                var datetime = entity.StarSysDateTime;
                var orbit = entity.GetDataBlob<OrbitDB>();

                var vel = orbit.InstantaneousOrbitalVelocityVector_m(datetime);
                return (pos, vel);
            }
            if (entity.HasDataBlob<OrbitUpdateOftenDB>())
            {
                var datetime = entity.StarSysDateTime;
                var orbit = entity.GetDataBlob<OrbitUpdateOftenDB>();
                var vel = orbit.InstantaneousOrbitalVelocityVector_m(datetime);
                return (pos, vel);
            }

            if (entity.HasDataBlob<NewtonMoveDB>())
            {
                var move = entity.GetDataBlob<NewtonMoveDB>();

                var vel = move.CurrentVector_ms;
                return (pos, vel);
            }

            if (entity.HasDataBlob<ColonyInfoDB>())
            {
                var daylen = entity.GetDataBlob<ColonyInfoDB>().PlanetEntity.GetDataBlob<SystemBodyInfoDB>().LengthOfDay.TotalSeconds;
                var radius = pos.Length();
                var d = 2 * Math.PI * radius;
                double speed = 0;
                if(daylen !=0)
                   speed = d / daylen;

                Vector3 vel = new Vector3(0, speed, 0);

                var posAngle = Math.Atan2(pos.Y, pos.X);
                var mtx = Matrix3d.IDRotateZ(posAngle + (Math.PI * 0.5));

                Vector3 transformedVector = mtx.Transform(vel);
                return (pos, transformedVector);
            }
            if(entity.HasDataBlob<WarpMovingDB>())
            {
                var warpdb = entity.GetDataBlob<WarpMovingDB>();
                return (pos, warpdb.CurrentNonNewtonionVectorMS);
            }
            else
            {
                throw new Exception("Entity has no velocity");
            }
        }

        public static (Vector3 pos, Vector3 Velocity) GetAbsoluteState(this Entity entity)
        {
            var posdb = entity.GetDataBlob<PositionDB>();
            var pos = posdb.AbsolutePosition;
            if (entity.HasDataBlob<OrbitDB>())
            {
                var datetime = entity.StarSysDateTime;
                var orbit = entity.GetDataBlob<OrbitDB>();
                var vel = orbit.InstantaneousOrbitalVelocityVector_m(datetime);
                if (posdb.Parent != null)
                {
                    vel += posdb.Parent.GetAbsoluteState().Velocity;
                }

                return (pos, vel);
            }
            if (entity.HasDataBlob<OrbitUpdateOftenDB>())
            {
                var datetime = entity.StarSysDateTime;
                var orbit = entity.GetDataBlob<OrbitUpdateOftenDB>();
                var vel = orbit.InstantaneousOrbitalVelocityVector_m(datetime);
                if (posdb.Parent != null)
                {
                    vel += posdb.Parent.GetAbsoluteState().Velocity;
                }
                return (pos, vel);
            }

            if (entity.HasDataBlob<NewtonMoveDB>())
            {
                var move = entity.GetDataBlob<NewtonMoveDB>();
                var vel = move.CurrentVector_ms;
                return (pos, vel);
            }
            if(entity.HasDataBlob<WarpMovingDB>())
            {
                var vel = entity.GetDataBlob<WarpMovingDB>().CurrentNonNewtonionVectorMS;
                return(pos,vel);
            }
            else
            {
                throw new Exception("Entity has no velocity");
            }
        }

        public static (Vector3 pos, Vector3 Velocity) GetRelativeFutureState(this Entity entity, DateTime atDateTime)
        {
            var fvel = GetRelativeFutureVelocity(entity, atDateTime);
            var fpos = GetRelativeFuturePosition(entity, atDateTime);

            return (fpos, fvel);
        }

        /// <summary>
        /// Gets future velocity for this entity, datablob agnostic.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="atDateTime"></param>
        /// <returns>Velocity in m/s relative to SOI parent</returns>
        /// <exception cref="Exception"></exception>
        public static Vector3 GetRelativeFutureVelocity(this Entity entity, DateTime atDateTime)
        {

            if (entity.HasDataBlob<OrbitDB>())
            {
                return entity.GetDataBlob<OrbitDB>().InstantaneousOrbitalVelocityVector_m(atDateTime);
            }
            if (entity.HasDataBlob<OrbitUpdateOftenDB>())
            {
                return entity.GetDataBlob<OrbitUpdateOftenDB>().InstantaneousOrbitalVelocityVector_m(atDateTime);
            }
            else if (entity.HasDataBlob<NewtonMoveDB>())
            {
                return NewtonionMovementProcessor.GetRelativeState(entity, entity.GetDataBlob<NewtonMoveDB>(), atDateTime).vel;
            }
            else if (entity.HasDataBlob<WarpMovingDB>())
            {
                return entity.GetDataBlob<WarpMovingDB>().SavedNewtonionVector;
            }
            else
            {
                throw new Exception("Entity has no velocity");
            }
        }

        /// <summary>
        /// Gets future velocity for this entity, datablob agnostic.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="atDateTime"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Vector3 GetAbsoluteFutureVelocity(this Entity entity, DateTime atDateTime)
        {
            if (entity.HasDataBlob<OrbitDB>())
            {
                return entity.GetDataBlob<OrbitDB>().AbsoluteOrbitalVector_m(atDateTime);
            }
            if (entity.HasDataBlob<OrbitUpdateOftenDB>())
            {
                return entity.GetDataBlob<OrbitUpdateOftenDB>().AbsoluteOrbitalVector_m(atDateTime);
            }
            else if (entity.HasDataBlob<NewtonMoveDB>())
            {
                var vel = NewtonionMovementProcessor.GetRelativeState(entity, entity.GetDataBlob<NewtonMoveDB>(), atDateTime).vel;
                //recurse
                return GetAbsoluteFutureVelocity(GetSOIParentEntity(entity), atDateTime) + vel;
            }
            else if (entity.HasDataBlob<WarpMovingDB>())
            {
                return entity.GetDataBlob<WarpMovingDB>().SavedNewtonionVector;
            }
            else
            {
                throw new Exception("Entity has no velocity");
            }
        }



        /// <summary>
        /// Gets a future position for this entity, regarless of wheter it's orbit or newtonion trajectory
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="atDateTime"></param>
        /// <returns>In Meters</returns>
        /// <exception cref="Exception"> if entity doesn't have one of the correct datablobs</exception>
        public static Vector3 GetRelativeFuturePosition(this Entity entity, DateTime atDateTime)
        {
            if (entity.HasDataBlob<OrbitDB>())
            {
                return entity.GetDataBlob<OrbitDB>().GetPosition(atDateTime);
            }
            else if (entity.HasDataBlob<OrbitUpdateOftenDB>())
            {
                return entity.GetDataBlob<OrbitUpdateOftenDB>().GetPosition(atDateTime);
            }
            else if (entity.HasDataBlob<NewtonMoveDB>())
            {
                return NewtonionMovementProcessor.GetRelativeState(entity, entity.GetDataBlob<NewtonMoveDB>(), atDateTime).pos;
            }
            else if (entity.HasDataBlob<PositionDB>())
            {
                return entity.GetDataBlob<PositionDB>().RelativePosition;
            }
            else
            {
                throw new Exception("Entity is positionless");
            }
        }

        /// <summary>
        /// Gets a future position for this entity, regarless of wheter it's orbit or newtonion trajectory
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="atDateTime"></param>
        /// <returns>In Meters</returns>
        /// <exception cref="Exception"> if entity doesn't have one of the correct datablobs</exception>
        public static Vector3 GetAbsoluteFuturePosition(this Entity entity, DateTime atDateTime)
        {
            if (entity.HasDataBlob<OrbitDB>())
            {
                return entity.GetDataBlob<OrbitDB>().GetAbsolutePosition_m(atDateTime);
            }
            else if (entity.HasDataBlob<OrbitUpdateOftenDB>())
            {
                return entity.GetDataBlob<OrbitUpdateOftenDB>().GetAbsolutePosition_m(atDateTime);
            }
            else if (entity.HasDataBlob<NewtonMoveDB>())
            {
                return NewtonionMovementProcessor.GetAbsoluteState(entity, entity.GetDataBlob<NewtonMoveDB>(), atDateTime).pos;
            }
            else if (entity.HasDataBlob<PositionDB>())
            {
                return entity.GetDataBlob<PositionDB>().AbsolutePosition;
            }
            else
            {
                throw new Exception("Entity is positionless");
            }
        }

        /// <summary>
        /// For more efficent, get and store a reference to PositionDB.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Vector3 GetAbsolutePosition(this Entity entity)
        {
            return entity.GetDataBlob<PositionDB>().AbsolutePosition;
        }

        /// <summary>
        /// For more efficent, get and store a reference to PositionDB.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Vector3 GetRalitivePosition(this Entity entity)
        {
            return entity.GetDataBlob<PositionDB>().RelativePosition;
        }

        public static double GetSOI_m(this Entity entity)
        {
            var orbitDB = entity.GetDataBlob<OrbitDB>();
            if (orbitDB.Parent != null) //if we're not the parent star
            {
                var semiMajAxis = orbitDB.SemiMajorAxis;

                var myMass = entity.GetDataBlob<MassVolumeDB>().MassDry;

                var parentMass = orbitDB.Parent.GetDataBlob<MassVolumeDB>().MassDry;

                return OrbitMath.GetSOI(semiMajAxis, myMass, parentMass);
            }
            else return double.PositiveInfinity; //if we're the parent star, then soi is infinate.
        }

        /// <summary>
        /// Gets the SOI radius of a given body.
        /// </summary>
        /// <returns>The SOI radius in AU</returns>
        /// <param name="entity">Entity which has OrbitDB and MassVolumeDB</param>
        public static double GetSOI_AU(this Entity entity)
        {
            return Distance.MToAU(entity.GetSOI_m());
        }

        public static double GetFuelPercent(this Entity entity)
        {
            if(entity.TryGetDatablob<ShipInfoDB>(out var shipInfoDB) && entity.TryGetDatablob<VolumeStorageDB>(out var volumeStorageDB))
            {
                Guid thrusterFuel = Guid.Empty;
                foreach(var component in shipInfoDB.Design.Components.ToArray())
                {
                    if(!component.design.TryGetAttribute<NewtonionThrustAtb>(out var newtonionThrustAtb)) continue;
                    thrusterFuel = newtonionThrustAtb.FuelType;
                    break;
                }

                if(thrusterFuel == Guid.Empty) return 0;

                var fuelType = StaticRefLib.StaticData.GetICargoable(thrusterFuel);
                var typeStore = volumeStorageDB.TypeStores[fuelType.CargoTypeID];
                var freeVolume = volumeStorageDB.GetFreeVolume(fuelType.CargoTypeID);
                var percentFree = (freeVolume / typeStore.MaxVolume) * 100;
                var percentStored = Math.Round( 100 - percentFree, 3);

                return percentStored;
            }

            return 0;
        }

        public static (ICargoable, double) GetFuelInfo(this Entity entity)
        {
            if(entity.TryGetDatablob<ShipInfoDB>(out var shipInfoDB) && entity.TryGetDatablob<VolumeStorageDB>(out var volumeStorageDB))
            {
                Guid thrusterFuel = Guid.Empty;
                foreach(var component in shipInfoDB.Design.Components.ToArray())
                {
                    if(!component.design.TryGetAttribute<NewtonionThrustAtb>(out var newtonionThrustAtb)) continue;
                    thrusterFuel = newtonionThrustAtb.FuelType;
                    break;
                }

                if(thrusterFuel == Guid.Empty) return (null, 0);

                var fuelType = StaticRefLib.StaticData.GetICargoable(thrusterFuel);
                var typeStore = volumeStorageDB.TypeStores[fuelType.CargoTypeID];
                var freeVolume = volumeStorageDB.GetFreeVolume(fuelType.CargoTypeID);
                var percentFree = (freeVolume / typeStore.MaxVolume) * 100;
                var percentStored = Math.Round( 100 - percentFree, 3);

                return (fuelType, percentStored);
            }

            return (null, 0);
        }
    }
}
