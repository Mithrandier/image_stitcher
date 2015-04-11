using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Pictures {
  public abstract class Picture {
    protected Bitmap original_image;
    public int Width { get { return original_image.Width; } }
    public int Height { get { return original_image.Height; } }
    public abstract uint this[int x, int y] { get; set; }

    public void EachPixel(PixelIterator iterator) {
      for (int y = 0; y < Height; y++) {
        int y_offset = y * Width;
        for (int x = 0; x < Width; x++) {
          iterator.Invoke(x, y, Array[y_offset + x]);
        }
      }
    }

    protected byte[] _byte_array;
    public byte[] ByteArray {
      get {
        if (_byte_array == null)
          _byte_array = ImageToByteArray();
        return _byte_array;
      }
    }
    protected byte[] ImageToByteArray() {
      int data_size = Width * Height * 4;
      byte[] raw_data = new byte[data_size];
      var image_data = original_image.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      Marshal.Copy(image_data.Scan0, raw_data, 0, data_size);
      original_image.UnlockBits(image_data);
      return raw_data;
    }

    protected uint[] _int_array;
    public uint[] Array {
      get {
        if (_int_array == null)
          _int_array = BytesToIntArray();
        return _int_array;
      }
      set {
        if (value.Length != _int_array.Length) throw new ArgumentException();
        _int_array = value;
      }
    }
    protected uint[] BytesToIntArray() {
      int length = Height * Width;
      uint[] int_data = new uint[length];
      for (int i = 0; i < length; i++) {
        int iStart = i * 4;
        int_data[i] = (uint)BitConverter.ToInt32(ByteArray, iStart);
        continue;
      }
      return int_data;
    }

    protected bool PixelInRange(int x, int y) {
      return !(x < 0 || x >= Width || y < 0 || y >= Height);
    }
  }
}
