Projection Matrices

Vulkan Canonical View Volume: A box with (2, 2, 1) that x-Axis is [-1, 1], y-Axis is [-1, 1] and z-Axis is [0, 1]
It differs from OpenGL, DirectX, etc...

I. Orthographic Matrix (based on left, right, bottom, top, far, near)

2/(r-l) 0       0       -(r+l)/(r-l)
0       2/(b-t) 0       -(b+t)/(b-t)
0       0       1/(f-n) -n/(f-n)
0       0       0       1


II. Perspective Matrix (based on far, near)

n       0       0       0
0       n       0       0
0       0       (f+n)   -f*n
0       0       1       0


III. Perspective Projection Matrix (I * II) (Center Off)

2*n/(r-l)   0           -(r+l)/(r-l)    0
0           2*n/(b-t)   -(b+t)/(b-t)    0
0           0           f/(f-n)         -f*n/(f-n)
0           0           1               0


IV. Perspective Projection Matrix (I * II) (Center Base)

n/r   0     0       0
0     n/b   0       0
0     0     f/(f-n) -f*n/(f-n)
0     0     1       0


V. Perspective Projection Matrix (I * II) (Base on aspect ratio and vertical field of view)

bottom  = n*tan(angle/2)
right   = n*(w/h)*tan(angle/2)

1/(w/h)*tan(angle/2)    0                  -(r+l)/(r-l)    0
0                       1/tan(angle/2)     -(b+t)/(b-t)    0
0                       0                   f/(f-n)         -f*n/(f-n)
0                       0                   1               0


VI. Reverse-Perspective Projection Matrix (based on vertical-size and aspect ratio)

size = (r-l)/2
offset = distance from camera position
weight = percent of reverse perspective

1/((w/h)*size)  0           0           0
0               1/size      0           0
0               0           .0001       weight
0               0           weight      1 + weight*offset