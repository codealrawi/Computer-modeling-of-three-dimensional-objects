import matplotlib.pyplot as plt
from matplotlib import patches


def draw_quadrants_arcs(xcenter, ycenter, radii, lw=2, ec='crimson', ax=None):
    ax = ax or plt.gca()
    for rad, theta in zip(radii, [0, 90, 180, 270]):
        arc = patches.Arc((xcenter, ycenter), 2*rad, 2*rad, theta1=theta, theta2=theta+90,
                              lw=lw, ec=ec, fc='none')
        ax.add_patch(arc)
    ax.hlines([ycenter, ycenter], [xcenter + radii[0], xcenter - radii[1]], [xcenter + radii[3], xcenter - radii[2]],
              lw=lw, colors=ec)
    ax.vlines([xcenter, xcenter], [ycenter + radii[0], ycenter - radii[2]], [ycenter + radii[1], ycenter - radii[3]],
              lw=lw, colors=ec)

def draw_quadrants_wedges(xcenter, ycenter, radii, lw=2, ec='crimson', fc='lime', alpha=1, ax=None):
    ax = ax or plt.gca()
    for rad, theta in zip(radii, [0, 90, 180, 270]):
        wedge = patches.Wedge((xcenter, ycenter), rad, theta, theta + 90,
                              lw=lw, ec=ec, fc=fc, alpha=alpha)
        ax.add_patch(wedge)

xcenter, ycenter = 6, 10
radii = [6, 2, 4, 7]
# only wedges
draw_quadrants_wedges(xcenter, ycenter, radii)
# only arcs
draw_quadrants_arcs(xcenter+12, ycenter, radii)
# wedges and arcs together
draw_quadrants_wedges(xcenter+24, ycenter, radii, ec='none', lw=0, fc='limegreen', alpha=0.3)
draw_quadrants_arcs(xcenter+24, ycenter, radii)

plt.xlim(0, 40)
plt.ylim(0, 20)
plt.gca().set_aspect('equal', 'box')
plt.show()