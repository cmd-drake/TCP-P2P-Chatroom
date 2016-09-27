#!/usr/bin/env python

import socket, threading
host = "localhost"
port = 12000
ipList = []
ipStr = ""

class ClientThread(threading.Thread):

    def __init__(self,ip,port,clientsocket):
        threading.Thread.__init__(self)
        self.ip = ip
        self.port = port
        self.csocket = clientsocket
        print "[+] New thread started for "+ip+":"+str(port)
        ipList.extend([ip])
        print '[%s]' % ', '.join(map(str, ipList))
        

    def run(self):    
        print "Connection from : "+ip+":"+str(port) + "\n"
        ipStr = ",".join(ipList )
        
        clientsock.send(ipStr)

        data = "dummydata"

        while len(data):
            data = self.csocket.recv(2048)
            self.csocket.send("You sent me : "+data)

            print "Client(%s:%s) sent : %s"%(self.ip, str(self.port), data)
            if data == "ping":
                print "ping"
                ipStr = ",".join(ipList)
                clientsock.send(ipStr)

            print '[%s]' % ', '.join(map(str, ipList))
            if data == "exit":
                data =""

        print "Client at "+self.ip+" disconnected..."
        ipList.remove(ip)
        print '[%s]' % ', '.join(map(str, ipList))




tcpsock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
tcpsock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

tcpsock.bind((host,port))

while True:
    tcpsock.listen(4)
    print "Listening for incoming connections..."
    (clientsock, (ip, port)) = tcpsock.accept()

    #pass clientsock to the ClientThread thread object being created
    newthread = ClientThread(ip, port, clientsock)
    newthread.start()
