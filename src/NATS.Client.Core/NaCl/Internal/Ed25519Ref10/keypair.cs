﻿// Copyright 2019 The NATS Authors
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Borrowed from https://github.com/CryptoManiac/Ed25519

using System;

namespace NATS.Client.Core.NaCl.Internal.Ed25519Ref10
{
    internal static partial class Ed25519Operations
    {
        public static void crypto_sign_keypair(
            byte[] pk,
            int pkoffset,
            byte[] sk,
            int skoffset,
            byte[] seed,
            int seedoffset
        )
        {
            GroupElementP3 A;
            int i;

            Array.Copy(seed, seedoffset, sk, skoffset, 32);
            byte[] h = Sha512.Hash(sk, skoffset, 32); //ToDo: Remove alloc
            ScalarOperations.sc_clamp(h, 0);

            GroupOperations.ge_scalarmult_base(out A, h, 0);
            GroupOperations.ge_p3_tobytes(pk, pkoffset, ref A);

            for (i = 0; i < 32; ++i)
                sk[skoffset + 32 + i] = pk[pkoffset + i];
            CryptoBytes.Wipe(h);
        }
    }
}
