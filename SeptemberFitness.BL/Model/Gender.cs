using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// М.Ж. название.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола.</param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Пол не может быть Null или пустым", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
