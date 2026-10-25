# Jeomseon Unity Components

[English](Overview.en.md) · [설치](../README.md)

## 목적

MovementTracker가 Transform의 FixedUpdate 간 위치 차이를 관찰하고 이동 시작·지속·종료 이벤트를 제공합니다.

## 사용 흐름

Tracker 추가 → MoveBegan/MoveOngoing/MoveEnded 구독 → 매 FixedUpdate에서 threshold 비교 → 수명 종료 전 구독 해제. Inspector 연결은 MovementTrackerUnityEventRelay를 사용합니다.

## 계약과 제한

이벤트 인자는 속도가 아닌 위치 delta입니다. threshold는 0.01~0.5로 제한됩니다. 이동을 제어하거나 Rigidbody 충돌을 계산하지 않으며, OnEnable마다 이전 위치를 재설정합니다.

## 패키지 요구 사항

- Package ID: `com.jeomseon.unity.components`
- Version: `0.3.1`
- Unity: `6000.6` / `0f1`

## 샘플과 검증

Package Manager > Samples에서 다음 예제를 Import하세요. 포함된 Scene 또는 Editor 도구를 열고 샘플 README의 Setup 절차를 먼저 수행합니다.

- [Basic Usage](../Samples~/BasicUsage/README.md)
  - [MovementTrackerPlayModeSample](../Samples~/BasicUsage/MovementTrackerPlayModeSample.unity)

## 코드 지도

- [MovementTracker](../Runtime/MovementTracker.cs)
- [MovementTrackerUnityEventRelay](../Runtime/MovementTrackerUnityEventRelay.cs)
