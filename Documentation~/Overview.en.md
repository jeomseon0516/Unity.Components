# Jeomseon Unity Components

[한국어](Overview.md) · [Installation](../README.en.md)

## Purpose

MovementTracker observes Transform displacement between FixedUpdates and emits movement start/ongoing/end events.

## Usage flow

Attach a Tracker, subscribe to MoveBegan/MoveOngoing/MoveEnded, compare displacement each FixedUpdate, and unsubscribe on shutdown. Use MovementTrackerUnityEventRelay for Inspector responses.

## Contracts and limitations

Payloads are position deltas, not velocity. Threshold is clamped to 0.01–0.5. It does not control movement or simulate collisions; OnEnable resets the previous position.

## Package requirements

- Package ID: `com.jeomseon.unity.components`
- Version: `0.3.1`
- Unity: `6000.6` / `0f1`

## Samples and verification

Import the following from Package Manager > Samples. Open the included Scene or Editor tool; follow any Setup step in its sample README.

- [Basic Usage](../Samples~/BasicUsage/README.md)
  - [MovementTrackerPlayModeSample](../Samples~/BasicUsage/MovementTrackerPlayModeSample.unity)

## Source map

- [MovementTracker](../Runtime/MovementTracker.cs)
- [MovementTrackerUnityEventRelay](../Runtime/MovementTrackerUnityEventRelay.cs)
