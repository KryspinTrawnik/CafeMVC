using AutoMapper; // CTRL + K + E

namespace CafeMVC.Application.Interfaces.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
