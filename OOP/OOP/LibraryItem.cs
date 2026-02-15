using System;

namespace OOP
{
    public abstract class LibraryItem
    {
        public string Id { get; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        protected LibraryItem(string id, string title, int publishedYear)
        {
            Id = id;
            Title = title;
            PublishedYear = publishedYear;
            IsAvailable = true;
        }

        public abstract string GetInfo();

        public virtual string GetItemType()
        {
            return this.GetType().Name;
        }
    }
}
