from http import server
host = "192.168.1.105"
port = 1234

class handler(server.SimpleHTTPRequestHandler):
    def do_HEAD(self):
        self.send_response(200,"OK")
        self.send_header("Date:",server.SimpleHTTPRequestHandler.date_time_string(self))
        self.send_header("connection:","Keep-Alive")
        self.send_header("connection:","Keep-Alive")
        self.send_header("Content-Type:","text/html;charset=utf-8")
        self.end_headers()
    def do_GET(self):
        
        return server.SimpleHTTPRequestHandler.do_GET(self)




if __name__ == '__main__':
    web_server = server.HTTPServer((host,port),handler)
    print("connecting")
    try:
        web_server.serve_forever()
    except KeyboardInterrupt:
        pass

    web_server.server_close()
    print("bye bye")




