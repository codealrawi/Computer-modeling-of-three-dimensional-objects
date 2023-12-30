import matplotlib.pyplot as plt
import numpy as np

plt.rcParams["figure.figsize"] = [10, 10]
plt.rcParams["figure.autolayout"] = True

fig = plt.figure()

ax = fig.add_subplot(111, projection='3d')
x = np.array(np.linspace(-10, 4, 100))
y = np.array(np.linspace(-10, 10, 100))

a = float(input("Введите коэффициент a "))
b = float(input("Введите коэффициент b "))

X, Y = np.meshgrid(x, y)
Z = a * (X ** 2) + b * (Y ** 3)
ax.plot_surface(X, Y, Z, rstride=1, cstride=1, cmap="plasma", linewidth=0, antialiased=False)

plt.show()