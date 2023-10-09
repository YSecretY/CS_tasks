﻿using patterns.decorator.classes;
using patterns.decorator.decorators;
using patterns.decorator.interfaces;

namespace patterns;

class Program
{
    static void Main()
    {
        Message message = new Message("Test message");
        ILogger logger = new Logger();

        logger = new EncryptionDecorator(logger);
        if (logger is EncryptionDecorator encryptionLogger)
        {
            encryptionLogger.WriteEncrypted(message);
        }

        logger = new CompressionDecorator(logger);
        if (logger is CompressionDecorator compressionLogger)
        {
            compressionLogger.WriteCompressed(message);
        }
    }
}