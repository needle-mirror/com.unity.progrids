using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.ProGrids;
using UObject = UnityEngine.Object;

namespace UnityEditor.ProGrids.Tests
{
	public class IgnoreAttributeIsRespected
	{
		[Test]
		public void GameObjectWithIgnoreAttribIsNotSnapped()
		{
			var go = new GameObject();
			Assert.IsTrue(EditorUtility.SnapIsEnabled(go.transform));
			EditorUtility.ClearSnapEnabledCache();
			go.AddComponent<IgnoreSnap>();
			Assert.IsFalse(EditorUtility.SnapIsEnabled(go.transform));
			UObject.DestroyImmediate(go);
		}

		[Test]
		public void GameObjectWithConditionalIgnoreAttribIsNotSnapped()
		{
			var go = new GameObject();
			Assert.IsTrue(EditorUtility.SnapIsEnabled(go.transform));
			var attrib = go.AddComponent<IgnoreSnapConditionalAttribute>();
			EditorUtility.ClearSnapEnabledCache();
			attrib.m_SnapEnabled = false;
			Assert.IsFalse(EditorUtility.SnapIsEnabled(go.transform));
			UObject.DestroyImmediate(go);
		}

		[Test]
		public void GameObjectWithConditionalIgnoreAttribIsSnapped()
		{
			var go = new GameObject();
			Assert.IsTrue(EditorUtility.SnapIsEnabled(go.transform));
			var attrib = go.AddComponent<IgnoreSnapConditionalAttribute>();
			EditorUtility.ClearSnapEnabledCache();
			attrib.m_SnapEnabled = true;
			Assert.IsTrue(EditorUtility.SnapIsEnabled(go.transform));
			UObject.DestroyImmediate(go);
		}
	}
}
