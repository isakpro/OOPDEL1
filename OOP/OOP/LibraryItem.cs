using System;

namespace OOP
{
    public abstract class LibraryItem
    {
        // EF-friendly primary key when used as entity
        public int Id { get; set; }

        // Legacy identifier (e.g. ISBN or custom id)
        public string ExternalId { get; set; }

        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        protected LibraryItem(string externalId, string title, int publishedYear)
        {
            ExternalId = externalId;
            Title = title;
            PublishedYear = publishedYear;
            IsAvailable = true;
        }

        protected LibraryItem()
        {
            ExternalId = string.Empty;
            Title = string.Empty;
            PublishedYear = 0;
            IsAvailable = true;
        }

        public abstract string GetInfo();

        public virtual string GetItemType()
        {
            return this.GetType().Name;
        }
    }
}
