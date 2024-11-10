
//-----------------------------------------------------------------
//    <copyright file="EquipmentStatus.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     This file contains the EquipmentStatus enum definition.
//    </summary>
//    <remarks>
//     This enum represents the various states an equipment item can be in.
//    </remarks>
//-----------------------------------------------------------------


namespace TP_POO_a30517.Enums
{
    /// <summary>
    /// Represents the status of equipment items.
    /// </summary>
    /// <remarks>
    /// This enum is used to track the current state of equipment,
    /// such as availability, allocation, or maintenance status.
    /// </remarks>
    public enum EquipmentStatus
    {
        Disponível,
        Alocado,
        Em_Manutenção,
        Sem_Stock,
        Indisponível,
        Outro
    }
}
