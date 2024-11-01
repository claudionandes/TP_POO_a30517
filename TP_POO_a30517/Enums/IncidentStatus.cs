﻿
//-----------------------------------------------------------------
//    <copyright file="IncidentStatus.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO_a30517.Enums
{
    /// <summary>
    /// Status of the incident
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
