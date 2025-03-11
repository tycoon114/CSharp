﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Day17
{
    public class GameObject
    {

        public List<Component> components = new List<Component>();

        public bool isTrigger = false;
        public bool isCollide = false;

        public string Name;


        protected static int gameObjectCount = 0;

        public Transform transform;

        public GameObject()
        {
            Init();
            gameObjectCount++;
            Name = $"GameObhect({gameObjectCount})";
        }

        ~GameObject()
        {
            gameObjectCount--;
        }

        public void Init()
        {
            transform = new Transform();
            AddComponent<Transform>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T inComponent = new T();
            AddComponent<T>(inComponent);

            return inComponent;
        }


        public T AddComponent<T>(T inComponent) where T : Component
        {
            components.Add(inComponent);
            inComponent.gameObject = this;
            inComponent.transform = transform;

            return inComponent;
        }

        public bool PredictCollision(int newX, int newY)
        {

            //for (int i = 0; i < Engine.Instance.world.GetAllGameObjects.Count; ++i)
            //{
            //    if (Engine.Instance.world.GetAllGameObjects[i].isCollide == true &&
            //            Engine.Instance.world.GetAllGameObjects[i].X == newX &&
            //            Engine.Instance.world.GetAllGameObjects[i].Y == newY)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public virtual void Update()
        {

        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }
            return null;
        }

        public void ExecuteMethod(string methodName, Object[] parameters)
        {
            //리플렉션
            foreach (var component in components)
            {
                Type type = component.GetType();
                MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (var methodInfo in methodInfos)
                {
                    if (methodInfo.Name.CompareTo(methodName) == 0)
                    {
                        methodInfo.Invoke(component, parameters);
                    }

                }

            }
        }

        public static GameObject Find(string gameObjectName)
        {
            foreach (var choiceObject in Engine.Instance.world.GetAllGameObjects)
            {
                if (choiceObject.Name.CompareTo(gameObjectName) == 0)
                {
                    return choiceObject;
                }
            }

            return null;
        }
    }
}



