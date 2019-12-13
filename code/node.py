# -*- coding: utf-8 -*-

import time

class Node(object):

	def __init__(self, oPrecondition):
		self._children = []
		self._precondition = oPrecondition

		# 执行CD
		self._internal = 0 #CD
		self._lastTimeEvaluated = 0 #上次执行时间

		self._active = True

	def SetActive(self, bValue):
		self._active = bValue

	def Evaluate(self):
		IsCoolDown = self._CheckTimer()
		return self._active and IsCoolDown and (self._precondition == None or self._precondition.Check()) and self.CanDoEvaluate()

	def _CheckTimer(self):
		if time.time() - self._lastTimeEvaluated > self._internal:
			self._lastTimeEvaluated = time.time()
			return True
		return False

	def CanDoEvaluate(self):
		return True

	def Clear(self):
		pass

	def Tick(self):
		pass

	def AddChild(self, oNode):
		if self._children == None:
			self._children = []
		if oNode:
			self._children.append(oNode)

	def RemoveChild(self, oNode):
		if self._children and oNode and oNode in self._children:
			self._children.remove(oNode)