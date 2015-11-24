using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POPfolio
{
    interface HTMLNode 
    {
        void printElement(StreamWriter writer, int depth);
        LinkedList<HTMLNode> getChildren();
        bool replaceChild(int index, HTMLNode node);
        bool addChild(int index, HTMLNode node);
        bool removeChild(int index);
        bool setUserInput(String str);
        String getUserInput();
    }
}
