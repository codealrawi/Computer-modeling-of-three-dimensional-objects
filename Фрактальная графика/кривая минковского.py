import turtle

size = 1000
from turtle import *
n = numinput("Кривая Минковского","введите n",0, minval=0, maxval=4)


def mink_curve(size, n):
    if n <= 0:
        turtle.forward(size)
        return

    mink_curve(size / 8, n - 1)
    turtle.left(90)
    mink_curve(size / 8, n - 1)
    turtle.right(90)
    mink_curve(size / 8, n - 1)
    turtle.right(90)
    mink_curve(size / 8, n - 1)
    mink_curve(size / 8, n - 1)
    turtle.left(90)
    mink_curve(size / 8, n - 1)
    turtle.left(90)
    mink_curve(size / 8, n - 1)
    turtle.right(90)
    mink_curve(size / 8, n - 1)


mink_curve(size, n)