import turtle


size = 200
from turtle import *
n = numinput("Кривая Коха","введите n",1, minval=1, maxval=4)


def set_color(color):
    global current_color
    turtle.color(color)
    current_color = color


def koch_curve(size, n):
    if n == 0:
        turtle.forward(size)
    else:
        koch_curve(size / 3, n - 1)
        turtle.left(60)
        koch_curve(size / 3, n - 1)
        turtle.right(120)
        koch_curve(size / 3, n - 1)
        turtle.left(60)
        koch_curve(size / 3, n - 1)
        set_color(current_color)
        turtle.listen()

current_color = "green"
colors = {"red", "blue", "green", "yellow", "orange"}

def draw_koch_snowflake(size, n):
    for i in range(3):
        koch_curve(size, n)
        turtle.right(120)

set_color(current_color)

draw_koch_snowflake(size, n)