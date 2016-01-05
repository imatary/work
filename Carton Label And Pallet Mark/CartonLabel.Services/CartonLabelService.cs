using System.Collections.Generic;
using System.Linq;
using CartonLabel.Data;

namespace CartonLabel.Services
{
    public class CartonLabelService
    {
        private readonly CartonLabelEntities _context;
        public CartonLabelService()
        {
            _context = new CartonLabelEntities();
        }

        public List<Data.Label> GetCartonLabels()
        {
            using (var context=new CartonLabelEntities())
            {
                return context.Labels.ToList();
            }
        }

        public Data.Label GetCartonLabelById(int id)
        {
            return _context.Labels.FirstOrDefault(l => l.ID == id);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="label"></param>
        public void Add(Data.Label label)
        {
            _context.Labels.Add(label);
            SaveChanges();
        }

        public void Delete(Data.Label label)
        {
            Data.Label labelDelete = GetCartonLabelById(label.ID);
            _context.Labels.Remove(labelDelete);
            SaveChanges();
        }

        /// <summary>
        /// Save Changes
        /// </summary>
        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}