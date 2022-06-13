﻿using MediatR;
using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetDayScheduleQuery : IRequest<List<ScheduleSubjectDTO>>
    {
        public uint Class_id { get; set; }
        public DayOfWeek dayofweek { get; set; }
        public GetDayScheduleQuery(uint Class_id, DayOfWeek dayofweek)
        {
            this.Class_id = Class_id;
            this.dayofweek = dayofweek;
        }
    }
}
