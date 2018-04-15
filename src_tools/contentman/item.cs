/* 
 * Project Item
 * =====================================================================
 * FileName: item.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;

namespace Troya.Tools
{
    public class ProjectItem : EventArgs
    {
        public enum ContentType
        {
            Font,
            Model,
            StudioModel,
            GameModel,
            Texture,
            Shader,
            Sound
        };

        public enum GDProfile
        {
            HiDef,
            Reach
        };

        string fileAsset;
        ContentType fileContentType = ContentType.Font;
        bool build = true;
        GDProfile profile = GDProfile.HiDef;
        

        public string FileAsset {
            get { return this.fileAsset; }
        }
        public ContentType FileContentType {
            get { return this.fileContentType; }
            set { this.fileContentType = value; }
        }
        public bool Build {
            get { return this.build; }
            set { this.build = value; }
        }
        public GDProfile Profile {
            get { return this.profile; }
            set { this.profile = value; }
        }

        public ProjectItem( string fileAsset, ContentType contentType, bool build = true, GDProfile profile = GDProfile.HiDef ) {
            this.fileAsset = fileAsset;
            this.fileContentType = contentType;
            this.build = build;
            this.profile = profile;
        }
    }
}