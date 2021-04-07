using System;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private TargetTrackableEventHandler targetEventHandler;
    [SerializeField] private RectTransform linkedInButton;
    [SerializeField] private RectTransform githubButton;
    [SerializeField] private RectTransform twitterButton;
    [SerializeField] private RectTransform text;
    
    private void Start()
    {
        SetElementsSize();
    }

    private void OnEnable()
    {
        targetEventHandler.onTargetDetected += RunAnimations;
        targetEventHandler.onTargetLost += SetElementsSize;
    }

    private void OnDisable()
    {
        targetEventHandler.onTargetDetected -= RunAnimations;
        targetEventHandler.onTargetLost -= SetElementsSize;
    }

    public void RunAnimations()
    {
        LeanTween.scale(linkedInButton, Vector3.one, 1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(githubButton, Vector3.one, 1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(twitterButton, Vector3.one, 1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(text, Vector3.one, 1f).setEase(LeanTweenType.easeOutBack);
    }

    public void SetElementsSize()
    {
        linkedInButton.localScale = Vector3.zero;
        githubButton.localScale = Vector3.zero;
        twitterButton.localScale = Vector3.zero;
        text.localScale = Vector3.zero;
    }
}
