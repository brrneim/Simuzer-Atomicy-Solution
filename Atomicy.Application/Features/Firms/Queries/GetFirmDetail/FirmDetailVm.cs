using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Firms.Queries.GetFirmDetail
{
    public class FirmDetailVm
    {
        public Guid FirmId { get; set; }
        public string Name { get; set; }
        public int VanCount { get; set; }
        public int TruckCount { get; set; }
        public int BigTruckCount { get; set; }
        public string Note { get; set; }

        public ICollection<FirmCommentDto> FirmCommentDtos { get; set; }
        public ICollection<FirmVehicleDto> FirmVehicleDtos { get; set; }

    }
}
