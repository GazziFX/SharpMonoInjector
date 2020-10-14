using System;
using System.Collections.Generic;

namespace SharpMonoInjector
{
    public class Assembler : List<byte>
    {
        public void MovRax(IntPtr arg)
        {
            AddRange(new byte[] {0x48, 0xB8});
            AddRange(BitConverter.GetBytes((long)arg));
        }

        public void MovRcx(IntPtr arg)
        {
            AddRange(new byte[] {0x48, 0xB9});
            AddRange(BitConverter.GetBytes((long)arg));
        }

        public void MovRdx(IntPtr arg)
        {
            AddRange(new byte[] {0x48, 0xBA});
            AddRange(BitConverter.GetBytes((long)arg));
        }

        public void MovR8(IntPtr arg)
        {
            AddRange(new byte[] {0x49, 0xB8});
            AddRange(BitConverter.GetBytes((long)arg));
        }

        public void MovR9(IntPtr arg)
        {
            AddRange(new byte[] {0x49, 0xB9});
            AddRange(BitConverter.GetBytes((long)arg));
        }

        public void SubRsp(byte arg)
        {
            AddRange(new byte[] {0x48, 0x83, 0xEC});
            Add(arg);
        }

        public void CallRax()
        {
            AddRange(new byte[] {0xFF, 0xD0});
        }

        public void AddRsp(byte arg)
        {
            AddRange(new byte[] {0x48, 0x83, 0xC4});
            Add(arg);
        }

        public void MovRaxTo(IntPtr dest)
        {
            AddRange(new byte[] { 0x48, 0xA3 });
            AddRange(BitConverter.GetBytes((long)dest));
        }

        public void Push(IntPtr arg)
        {
            Add((int)arg < 128 ? (byte)0x6A : (byte)0x68);
            AddRange((int)arg <= 255 ? new[] {(byte)arg} : BitConverter.GetBytes((int)arg));
        }

        public void MovEax(IntPtr arg)
        {
            Add(0xB8);
            AddRange(BitConverter.GetBytes((int)arg));
        }

        public void CallEax()
        {
            AddRange(new byte[] {0xFF, 0xD0});
        }

        public void AddEsp(byte arg)
        {
            AddRange(new byte[] {0x83, 0xC4});
            Add(arg);
        }

        public void MovEaxTo(IntPtr dest)
        {
            Add(0xA3);
            AddRange(BitConverter.GetBytes((int)dest));
        }

        public void Return()
        {
            Add(0xC3);
        }
    }
}
