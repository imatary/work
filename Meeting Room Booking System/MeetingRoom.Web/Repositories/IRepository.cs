using System;
using System.Linq;
using MeetingRoom.Web.Models;

namespace MeetingRoom.Repositories
{
    public interface IRepository : IDisposable
    {
        bool Insert<T>(T entity) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        bool Delete<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        //bool RemoveEvents(int id);

        bool UpdateEvents(CalendarEvent instance);
    }
}