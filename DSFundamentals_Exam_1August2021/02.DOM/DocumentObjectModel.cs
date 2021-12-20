namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root = new HtmlElement(
               ElementType.Document,
               new HtmlElement(ElementType.Html,
                   new HtmlElement(ElementType.Head),
                   new HtmlElement(ElementType.Body)
               )
           );
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var queueElements = new Queue<IHtmlElement>();

            queueElements.Enqueue(this.Root);

            while (queueElements.Count > 0)
            {
                var currentElements = queueElements.Dequeue();

                if (currentElements.Type == type)
                {
                    return currentElements;
                }

                foreach (var child in currentElements.Children)
                {
                    queueElements.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var result = new List<IHtmlElement>();

            this.ElementsByTypeDfs(this.Root, type, result);

            return result;
        }

        private void ElementsByTypeDfs(IHtmlElement current,
            ElementType type,
            List<IHtmlElement> result)
        {
            foreach (var child in current.Children)
            {
                this.ElementsByTypeDfs(child, type, result);
            }

            if (current.Type == type)
            {
                result.Add(current);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.FindElementHtml(htmlElement) != null;
        }

        private IHtmlElement FindElementHtml(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElements = queue.Dequeue();

                if (currentElements == htmlElement)
                {
                    return currentElements;
                }

                foreach (var child in currentElements.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            this.CheckIfExists(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        private void CheckIfExists(IHtmlElement element)
        {
            var foundElement = this.FindElementHtml(element);

            if (foundElement == null)
            {
                throw new InvalidOperationException("Html element not found in DOM tree!");
            }
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            this.CheckIfExists(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            this.CheckIfExists(htmlElement);
            this.RemoveReferences(htmlElement, htmlElement.Parent);
        }

        private void RemoveReferences(IHtmlElement currentElement, IHtmlElement parent)
        {
            parent.Children.Remove(currentElement);
            currentElement.Parent = null;
            currentElement.Children.Clear();
        }

        public void RemoveAll(ElementType elementType)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.Type == elementType)
                {
                    var parent = currentElement.Parent;

                    this.RemoveReferences(currentElement, parent);
                }
                else
                {
                    foreach (var child in currentElement.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            this.CheckIfExists(htmlElement);

            if (!htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Add(attrKey, attrValue);
                return true;
            }

            return false;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            this.CheckIfExists(htmlElement);

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Remove(attrKey);
                return true;
            }
            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentEl = queue.Dequeue();
                var attributes = currentEl.Attributes;

                if (attributes.ContainsKey("id"))
                {
                    if (attributes["id"] == idValue)
                    {
                        return currentEl;
                    }
                }

                foreach (var child in currentEl.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.CreateDfsText(this.Root, sb, 0);

            return sb.ToString();
        }

        private void CreateDfsText(IHtmlElement currElement, StringBuilder sb, int depth)
        {
            sb.AppendLine($"{new string(' ', depth)}{currElement.Type.ToString()}");

            foreach (var child in currElement.Children)
            {
                this.CreateDfsText(child, sb, depth + 2);
            }
        }
    }
}
