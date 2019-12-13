# -*- coding: utf-8 -*-

class Tree(object):

	def __init__(self):
		self._root = None
		self._bIsRunning = True
	
	def Update(self):
		if self._bIsRunning:
			return
		if self._root.Evaluate():
			self._root.Tick()

	def Destroy(self):
		if self._root is not None:
			self._root.Clear()
