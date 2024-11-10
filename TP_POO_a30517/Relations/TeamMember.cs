
//-----------------------------------------------------------------
//    <copyright file="TeamMember.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Models;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Relations
{
    /// <summary>
    /// Represents the association between a team and a member (person).
    /// </summary>
    public class TeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public EmergencyTeamBase Team { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }

}
