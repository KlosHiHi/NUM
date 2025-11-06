from array import *
import numpy as np

e = 0.01
A = np.array([
    [76, 33, -27],
    [25, -68, 25],
    [-13, -24, -47]
    ])

B = np.array([-22, -93, 56])

x1 = 0
x2 = 0
x3 = 0

x4 = ((B[0] - (A[0,1] * x2) - (A[0,2] * x3)) / A[0,0])
x5 = ((B[1] - (A[1,0] * x4) - (A[1,2] * x3)) / A[1,1])
x6 = ((B[2] - (A[2,0] * x4) - (A[2,1] * x5)) / A[2,2])
print(round(x4, 3), round(x5, 3),round(x6, 3))

while abs(x4-x1) > e and abs(x5-x2) > e and abs(x6-x3) > e :
    x1 = x4
    x2 = x5
    x3 = x6
    
    x4 = ((B[0] - (A[0,1] * x2) - (A[0,2] * x3)) / A[0,0])
    x5 = ((B[1] - (A[1,0] * x4) - (A[1,2] * x3)) / A[1,1])
    x6 = ((B[2] - (A[2,0] * x4) - (A[2,1] * x5)) / A[2,2])
    
    print(round(x4, 3), round(x5, 3),round(x6, 3))
    
print("Ответ", round(x4, 3), round(x5, 3),round(x6, 3))
