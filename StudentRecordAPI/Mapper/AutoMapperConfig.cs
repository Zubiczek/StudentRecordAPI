using AutoMapper;
using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.AddDTO;

namespace StudentRecordAPI.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NewUserDTO, UserEntity>();
                    cfg.CreateMap<GradeAddDTO, GradeEntity>();
                    cfg.CreateMap<AttendanceAddDTO, AttendanceEntity>();
                    cfg.CreateMap<NewScheduleDTO, ScheduleEntity>();
                    cfg.CreateMap<NoteAddDTO, NoteEntity>();
                    cfg.CreateMap<NewScheduleDTO, ScheduleEntity>();
                }
            ).CreateMapper();
    }
}
