﻿using System.Text;

namespace Wallop.Composer.Layout.Serializing.ChunkLoaders
{
    class AuthorLoader : IChunkLoader
    {
        public byte HandledType => ChunkInfo.CHUNK_AUTHOR;

        public void LoadChunk(ref ChunkInfo chunk, LayoutReader reader, byte[] buffer, LayoutInfo layout)
        {
            layout.Author = Encoding.Unicode.GetString(buffer);
        }
    }
}
