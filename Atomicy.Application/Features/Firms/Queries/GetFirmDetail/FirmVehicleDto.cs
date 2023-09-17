using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Firms.Queries.GetFirmDetail
{
    public class FirmVehicleDto
    {
        public Guid FirmVehicleId { get; set; }
        public Guid FirmId { get; set; }
        public string Plate { get; set; }
        public int DriverExperience { get; set; }
        public string DriverNote { get; set; }
        public string DriverName { get; set; }

        public Firm Firm { get; set; }

    }
}
