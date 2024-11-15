
//-----------------------------------------------------------------
//    <copyright file="IEmergencia.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the IEmergency interface for managing emergency operations.
//    </summary>
//-----------------------------------------------------------------


using TP_POO_a30517.Enums;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Defines methods for managing the lifecycle of an emergency
    /// </summary>
    public interface IEmergency
    {
        /// <summary>
        /// Initiates the emergency response
        /// </summary>
        void StartEmergency();

        /// <summary>
        /// Concludes the emergency response
        /// </summary>
        void ConcludeEmergency();
    }
}
