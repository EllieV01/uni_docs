class Stack:
    def __init__(self):
        self.stack = []
        self.max = None
    def pop(self):
        if len(self.stack) == 0:
            return None
        removed = self.stack.pop()
#        if len(self.stack) == 0:
#            self.max = None
#        elif removed == self.max:
#            self.max = self.stack[0]
#            for value in self.stack:
#                if value > self.max:
#                    self.max = value
        return removed
    def push(self, item):
        self.stack.append(item)
        if len(self.stack) == 1 or item > self.max:
            self.max = item
    def get_max(self):
        return self.max
    

    
import random 
stack = Stack()
for i in range(int(input("Enter amount of numbers"))):
    stack.push(random.randint(-10, 20)) 
    
print(stack.stack)    
print(stack.max)
