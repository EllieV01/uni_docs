#MLFQ
from time import sleep
from threading import Thread
import keyboard
from datetime import datetime
 
processes0 = [['ID', 'Memory', 'Time']]
processes1 = []
processes2 = []
processes3 = []
 
 
def add(*args):
    global processes1, processes2, processes3
    new_p = list(map(int, input().split()))
    processes1.append(new_p)
 
def go():
    global processes0, processes1, processes2, processes3
    bulb1 = 3
    bulb2 = 9
    while True:
        if len(processes1) != 0:
            if bulb1 == 0:
                processes2.append(processes1[0])
                processes1.pop(0)
                bulb1 = 3
            elif processes1[0][2] == 0 :
                processes1.pop(0)
                bulb1 = 3
            else:
                processes1[0][2] -= 1
                bulb1 -= 1
        elif len(processes2) != 0:
            if bulb2 == 0:
                processes3.append(processes2[0])
                processes2.pop(0)
                bulb2 = 9
            elif processes2[0][2] == 0 :
                processes2.pop(0)
                bulb1 = 9
            else:
                processes2[0][2] -= 1
                bulb2 -= 1
        elif len(processes3) != 0:
            if processes3[0][2] != 0:
                processes3[0][2] -= 1
            else:
                processes3.pop()
        processes = processes0 + processes1 + processes2 + processes3 
        sleep(3)
        for i in processes: 
            print(' '.join(list(map(str, i))))
        #print(datetime.now())
        
def go2():
    global processes0, processes1, processes2, processes3
 
if __name__ == "__main__":
    keyboard.on_release_key('left', add)    
    go_thread = Thread(target=go)

    go_thread.start()
    go_thread.join()