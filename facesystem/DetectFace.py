# -*- coding: utf-8 -*-
"""
Created on Sun Oct 18 16:55:15 2020

@author: Windink
"""
import cv2
import os


total_save_num=0
margin=10
savePath="data/stain/flower"
savePath="data/stain/other"
#savePath="data/stain/me"
classfier=cv2.CascadeClassifier("haarcascade_frontalface_alt2.xml")

def DetectFace(file):
    global total_save_num
    global margin
    print(file)
    fileName=file.split("/")[-1]
    print(fileName)
    img1=cv2.imread(file)
    img2=cv2.cvtColor(img1,cv2.COLOR_BGR2GRAY)
    faceRects=classfier.detectMultiScale(img2,scaleFactor=1.2,minNeighbors=3,minSize=(32,32))
    if len(faceRects) > 0:
        for faceRect in faceRects:
            x,y,w,h=faceRect
            imgName='%s/%s'%(savePath,fileName)
            print(imgName)
            y_begin,x_begin=max(y-margin,0),max(x-margin,0)
            y_end,x_end=min(y+h+margin,img1.shape[0]),min(x+w+margin,img1.shape[1])
            print("%s %s %s %s" % (y_begin,y_end,x_begin,x_end))
            saveImg=img1[y_begin:y_end,x_begin:x_end]
            cv2.imwrite(imgName,saveImg)    
    
    
    
def ScanPath(path):
    global total_save_num
    ld=os.listdir(path)
    #print(ld)
    for f in ld:
        file="%s/%s" % (path,f)
        #print(file)
        if os.path.isdir(file):
            #print("ScanPath")
            ScanPath(file)
        elif os.path.isfile(file):
            DetectFace(file)
            #print("DetectFace")
            
            
if __name__=='__main__':
    print("ss")
    ScanPath("data/flowers")