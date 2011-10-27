//
// Heap.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2011 Jb Evain
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata {

	abstract class Heap {

		public int IndexSize;

		public readonly Image Image;
		public readonly uint Offset;
		public readonly uint Size;

		protected Heap (Image image, uint offset, uint size)
		{
			this.Image = image;
			this.Offset = offset;
			this.Size = size;
		}

		public TRet ReadAt<TRet> (uint index, Func<BinaryStreamReader, TRet> read)
		{
			return Image.ReadAt(Image.MetadataSection.VirtualAddress, reader => { reader.Advance ((int)(Offset + index)); return read(reader); });
		}
	}
}
