using MediatR;
using StudentRecordAPI.Models.AddDTO;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.ScheduleFeatures.Commands
{
    public class UpdateWholeScheduleCommand : IRequest
    {
        public List<NewScheduleDTO> schedule { get; set; }
        public UpdateWholeScheduleCommand(List<NewScheduleDTO> schedule)
        {
            this.schedule = schedule;
        }
    }
}
