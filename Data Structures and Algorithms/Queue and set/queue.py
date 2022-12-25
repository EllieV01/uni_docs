class Queue:
    def __init__(self):
        self.queue = []
        self.first = None
    def push(self, item):
        if len(self.queue) == 0:
            self.first = item
        self.queue.append(item)
    def push_last(self, item):
        self.last = item
        self.queue.append(item)
    def pop(self):
        if len(self.queue) == 0:
            return None
        removed = self.queue.pop(0)        
        return removed
            
que = Queue()
n = int(input("Enter amount of symbols "))
for i in range(n-1):
    que.push(input("Enter symbol ")) 
que.push(input("Enter symbol ")) 
print(que.queue)
que.pop()

for i in range(n-2):
    a = que.pop()
    que.push(a) 
que.push(que.first) 
print(que.queue)
