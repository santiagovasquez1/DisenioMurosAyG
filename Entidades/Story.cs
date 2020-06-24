using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Story
    {
        public string StoryId { get; set; }
        public string StoryName { get; set; }
        public float StoryHeight { get; set; }
        public float StoryElevation { get; set; }

        public Story(string Name, float Height,float elevation)
        {
            StoryId = Guid.NewGuid().ToString();
            StoryName = Name;
            StoryHeight = Height;
            StoryElevation = elevation;
        }        

        public override string ToString()
        {
            return $"{StoryName}-{StoryHeight}";
        }

    }
}