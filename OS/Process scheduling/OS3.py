# MLQ
from time import sleep
from threading import Thread
import keyboard
from datetime import datetime
 
processes0 = [['ID', 'Priority', 'Time', 'Memory']]
processes1 = []
processes2 = []
processes3 = []
 
 
def add(*args):
    global processes1, processes2, processes3
    new_p = list(map(int, input().split()))
    if new_p[1] == 1:
        processes1.append(new_p)
    if new_p[1] == 2:
        processes2.append(new_p)
    if new_p[1] == 3:
        processes3.append(new_p)
 
def go():
    global processes0, processes1, processes2, processes3
    while True:
        if len(processes1) != 0:
            if processes1[0][2] != 0:
                processes1[0][2] -= 1
            else:
                processes1.pop()
        elif len(processes2) != 0:
            if processes2[0][2] != 0:
                processes2[0][2] -= 1
            else:
                processes2.pop()
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
 
if __name__ == "__main__":
    keyboard.on_release_key('left', add)    
    go_thread = Thread(target=go)

    go_thread.start()
    go_thread.join()