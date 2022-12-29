using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWidgets.SerializationSchema {
    public class Vector2 {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class OpenWidget {
        public string Type { get; set; }
        public string Path { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Scale { get; set; }
    }

    public class Root {
        public string Version { get; set; }
        public string LastSaved { get; set; }
        public List<OpenWidget> OpenWidgets { get; set; }
    }
}
