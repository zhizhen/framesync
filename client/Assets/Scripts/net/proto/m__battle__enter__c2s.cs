using System;
using Engine;
using System.Collections.Generic;
public class m__battle__enter__c2s : ProtoBase
{
    public m__battle__enter__c2s()
    {
        proto_id = 1200;
    }
    public override void write(ByteArray byteArray)
    {
        base.write(byteArray);
        byteArray.WriteInt32(proto_id);
    }
}
