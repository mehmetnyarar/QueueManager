using QueueManager.Abstracts;
using QueueManager.Interfaces;

namespace QueueManager.Models
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public class Person : QueueItem, IPerson
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QueueManager.Person"/> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        public Person(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Person's phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the <see cref="T:System.String"/> representation of the <see cref="T:QueueManager.Person"/>.
        /// </summary>
        /// <returns>Person as String.</returns>
        public override string ToString()
        {
            return string.Format("{0}", PhoneNumber);
        }

        #endregion
    }
}
