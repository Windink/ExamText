# -*- coding: utf-8 -*-
"""
Created on Sun Jan 10 14:30:59 2021

@author: Windink
"""
import os
from keras.models import load_model
from imagUnit import resize_image
import numpy as np

IMAGE_CLASSES = []

def Predict_Class(img,name):
    load_class()
    model = load_model("data/model/tesorflow-acc_1.00.h5")
    img = resize_image(img)
    imgs = np.expand_dims(img, axis=0)
    print(imgs.shape)
    imgs = imgs.astype('float32') / 255
    score = model.predict(imgs)
    y_pred = np.argmax(score,axis = 1)
    if score[1] > 0.95 && name == IMAGE_CLASSES[y_pred]:
        return  "true"
    else:
        return "false"
        
        
        
def load_class():
    path_name = "data/Face/"
    for item in os.listdir(path_name):
        full_path=os.path.abspath(os.path.join(path_name,item))
        lbl=full_path.split("\\")[-2]
        if lbl not in IMAGE_CLASSES:
            IMAGE_CLASSES.append(lbl)