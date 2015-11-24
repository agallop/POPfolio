using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPfolio
{
    class HTMLRoot : HTMLNode
    {
        private LinkedList<HTMLNode> children;

        public HTMLRoot() {
            children = new LinkedList<HTMLNode>();
            children.AddLast(new HeadNode());
            children.AddLast(new BodyNode());

        }
            
        public bool addChild(int index, HTMLNode node)
        {
            return false;
        }

        public LinkedList<HTMLNode> getChildren()
        {
            return children;
        }

        public string getUserInput()
        {
            return null;
        }

        public void printElement(StreamWriter writer, int depth)
        {
            writer.WriteLine("<html>");
            foreach(HTMLNode child in children)
            {
                child.printElement(writer, 1);
            }
            writer.WriteLine("</html>");
        }

        public bool removeChild(int index)
        {
            return false;
        }

        public bool replaceChild(int index, HTMLNode node)
        {
            return false;
        }

        public bool setUserInput(string str)
        {
            return false;
        }
    }
}
