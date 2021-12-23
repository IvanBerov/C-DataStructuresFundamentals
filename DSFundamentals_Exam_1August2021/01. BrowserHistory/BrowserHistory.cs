namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        List<ILink> links;

        public BrowserHistory()
        {
            this.links = new List<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear()
        {
            this.links.Clear();
        }

        public bool Contains(ILink link)
        {
            return this.links.Contains(link);
        }

        public void Open(ILink link)
        {
            this.links.Add(link);
        }

        public ILink DeleteFirst()
        {
            this.IsEmpty();
            var currentLink = this.links[0];
            this.links.RemoveAt(0);

            return currentLink;
        }

        private void IsEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public ILink DeleteLast()
        {
            this.IsEmpty();
            var currentLink = this.links[this.links.Count - 1];
            this.links.RemoveAt(this.links.Count - 1);

            return currentLink;

        }

        public ILink GetByUrl(string url)
        {
            foreach (var link in links)
            {
                if (link.Url == url)
                {
                    return link;
                }
            }
            return null;
        }

        public ILink LastVisited()
        {
            this.IsEmpty();
            return this.links[this.links.Count - 1];
        }

        public int RemoveLinks(string url)
        {
            var currLinks = new List<ILink>(this.links);
            int number = 0;

            foreach (var item in currLinks)
            {
                if (item.Url.Contains(url))
                {
                    number++;
                    this.links.Remove(item);
                }
            }

            if (number == 0)
            {
                throw new InvalidOperationException();
            }
            return number;
        }

        public ILink[] ToArray()
        {
            this.links.Reverse();
            return this.links.ToArray();
        }

        public List<ILink> ToList()
        {
            this.links.Reverse();
            return this.links;
        }

        public string ViewHistory()
        {
            if (this.Size == 0)
            {
                return "Browser history is empty!";
            }

            StringBuilder sb = new StringBuilder();

            for (int i = this.Size - 1; i >= 0; i--)
            {
                string asd = this.links[i]
                    .ToString();

                sb.AppendLine(asd);
            }
            return sb.ToString();
        }
    }
}
