Strong Name Key
===============

See [Strong Name Tool](http://msdn.microsoft.com/en-us/library/k5b5tt23.aspx)

Create the key pair

    sn -k Application.snk

Extract the public key

    sn -p Application.snk Application.pk

Extract the public key token

    sn -tp Application.pk > Application.txt