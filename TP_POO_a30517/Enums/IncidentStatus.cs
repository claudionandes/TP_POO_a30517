
//-----------------------------------------------------------------
//    <copyright file="IncidentStatus.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the status options for incidents.
//    </summary>
//-----------------------------------------------------------------


namespace TP_POO_a30517.Enums
{
    /// <summary>
    /// Represents the current status of an incident.
    /// </summary>
    public enum IncidentStatus
    {
        Em_Espera,
        Em_Progresso,
        Terminado,
        Cancelado,
        Falso_Incidente,
        Outro
    }
}
