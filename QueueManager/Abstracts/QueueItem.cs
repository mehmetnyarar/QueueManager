using System;
using QueueManager.Interfaces;

namespace QueueManager.Abstracts
{
    /// <summary>
    /// Generic queue item.
    /// </summary>
    public abstract class QueueItem: IQueueItem
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QueueManager.Abstracts.QueueItem"/> class.
        /// </summary>
        protected QueueItem()
        {
            Id = Guid.NewGuid().ToString("D");
        }

        #endregion

        #region Properties

        /// <summary>
        /// ID of the item.
        /// </summary>
        public string Id { get; set; }

        #endregion
    }
}
